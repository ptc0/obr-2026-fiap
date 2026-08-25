// Referências Sensores

string motor_esquerda_ref = "me";
string motor_direita_ref = "md";
string sensor_cor_esquerda_ref = "sce";
//string sensor_cor_meio_ref = "scm"; // TODO: Implementar sensor cor meio
string sensor_cor_direita_ref = "scd";


// Parametros

bool dbg = true; // modo de debug
double delay_exec = .2;
double vel_padrao = 200;
double vel_padrao_curva = 1000;
double vel_padrao_curva2 = -700;

// o sBotics se tiver em outra língua, os sensores vão reportar outra cor.. por algum motivo
// só vamos aceitar...

// Inglês
const string preto = "Black";
const string branco = "White";
const string vermelho = "Red";
const string verde = "Green";

/* const string preto = "Preto";
const string branco = "Branco";
const string vermelho = "Vermelho";
const string verde = "Verde"; */

// Movimentos
async Task andar_frente(double velocidade = 100) {
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = false; // Destrava o motor da direita
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = false; // Destrava o motor da esquerda
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(Math.Abs(velocidade), velocidade); //  velocidade de rotação e torque
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(Math.Abs(velocidade), velocidade); // velocidade de rotação e torque
}
async Task virar_esquerda(double velocidade = 200, double tick = 0.9) {
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(900, vel_padrao_curva2);
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = false; // Destrava o motor da direita
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(Math.Abs(velocidade * 2), velocidade * 2); //*
    await Time.Delay(tick);
}
// Mesclar o virar_direita e o virar_esquerda ele deve receber o parametro se é direita ou esquerda
async Task virar_direita(double velocidade = 200, double tick = 0.9) {
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(900, vel_padrao_curva2);
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = false; // Destrava o motor da esquerda
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(Math.Abs(velocidade * 2), velocidade * 2);
    await Time.Delay(tick);
}
async Task volta(double velocidade = 100) {
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = false;
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = false;
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(Math.Abs(0 - velocidade), 0 - velocidade);
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(Math.Abs(0 - velocidade), 0 - velocidade);
}
async Task travar_motor()
{ // 
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = true; // Trava o motor da direita
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = true; // Trava o motor da esquerda
}

async Task Main()
{
    IO.OpenConsole();

    while (true)
    {
        await Time.Delay(delay_exec);

        string info_sensor_cor_esquerda = (Bot.GetComponent<ColorSensor>(sensor_cor_esquerda_ref).Analog).ToString();
        string info_sensor_cor_direita = (Bot.GetComponent<ColorSensor>(sensor_cor_direita_ref).Analog).ToString();

        // informações de leitura dos sensores de cor (para debugging)
        if (dbg) IO.PrintLine($"{sensor_cor_esquerda_ref}: {(Bot.GetComponent<ColorSensor>(sensor_cor_esquerda_ref).Analog).ToString()} :: {sensor_cor_direita_ref}: {(Bot.GetComponent<ColorSensor>(sensor_cor_direita_ref).Analog).ToString()}");

        if (
            (info_sensor_cor_direita == preto) && //detectar se nececita de virar a esquerda
            (info_sensor_cor_esquerda != preto)
        )
        {
            if (dbg) IO.PrintLine("Direita");
            await virar_direita(vel_padrao_curva, .9);

        }
        else if (
            (info_sensor_cor_direita != preto) && //detectar se nececita de virar a direita
            (info_sensor_cor_esquerda == preto)
        )
        {
            if (dbg) IO.PrintLine("Esquerda");
            await virar_esquerda(vel_padrao_curva, .9);
        }
        else if (
            (info_sensor_cor_direita == preto) && //detecta se está tudo bem seguir em frente
            (info_sensor_cor_esquerda == preto)
        )
        {
            if (dbg) IO.PrintLine("Frente");
            await andar_frente(vel_padrao);
        }
        else if (
            (info_sensor_cor_direita == vermelho) || //parar na linha de chegada
            (info_sensor_cor_esquerda == vermelho)
        )
        {
            if (dbg) IO.PrintLine("Travar");
            await travar_motor();
        }
        else
        {
            if (dbg) IO.PrintLine("Frente");
            await andar_frente(vel_padrao); //se não parar andar pra frente
        }
    }
}