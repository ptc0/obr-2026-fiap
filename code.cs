string motor_esquerda_ref = "me";
string motor_direita_ref = "md";
string sensor_cor_esquerda_ref = "sce";
string sensor_cor_meio_ref = "scm";
string sensor_cor_direita_ref = "scd";

async Task andar_frente(double velocidade = 100) {
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = false; // Destrava o motor da direita
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = false; // Destrava o motor da esquerda
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(Math.Abs(velocidade), velocidade); //  velocidade de rotação e torque
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(Math.Abs(velocidade), velocidade); // velocidade de rotação e torque
}
async Task virar_esquerda(double velocidade = 200) {
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(0, 0);
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = true; // Trava o motor da esquerda
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = false; // Destrava o motor da direita
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(Math.Abs(velocidade * 2), velocidade * 2); //*
}
        //---------mesclar o virar_direita e o virar_esquerda ele deve receber o parametro se é direita ou esquerda-------------------------
async Task virar_direita(double velocidade = 200) {
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(0, 0);
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = true; // Trava o motor da direita
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = false; // Destrava o motor da esquerda
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(Math.Abs(velocidade * 2), velocidade * 2);
}
async Task volta(double velocidade = 100) { //----------------------ele deveria virar 180°-----------------
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = false; // Destrava o motor da direita
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = false; // Destrava o motor da esquerda
    Bot.GetComponent<Servomotor>(motor_direita_ref).Apply(Math.Abs(0 - velocidade), 0 - velocidade); // 
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Apply(Math.Abs(0 - velocidade), 0 - velocidade); // 
}

async Task travar_motor() { // 
    Bot.GetComponent<Servomotor>(motor_direita_ref).Locked = true ; // Trava o motor da direita
    Bot.GetComponent<Servomotor>(motor_esquerda_ref).Locked = true ; // Trava o motor da esquerda
}




// main function


async Task Main() {
    while (true) {
        await Time.Delay(0.2); // pro treco nao explodir, anti kaboom 3000
        
        if (
            ((Bot.GetComponent<ColorSensor>(sensor_cor_direita_ref).Analog).ToString() == "Preto") && //detectar se nececita de virar a esquerda
            ((Bot.GetComponent<ColorSensor>(sensor_cor_esquerda_ref).Analog).ToString() != "Preto")
        ) {
            await virar_direita(200);
    
        } else if (
            ((Bot.GetComponent<ColorSensor>(sensor_cor_direita_ref).Analog).ToString() != "Preto") && //detectar se nececita de virar a direita
            ((Bot.GetComponent<ColorSensor>(sensor_cor_esquerda_ref).Analog).ToString() == "Preto")
        ) {
            await virar_esquerda(200);
        } else if (
            ((Bot.GetComponent<ColorSensor>(sensor_cor_direita_ref).Analog).ToString() == "Preto") && //detecta se está tudo bem seguir em frente
            ((Bot.GetComponent<ColorSensor>(sensor_cor_esquerda_ref).Analog).ToString() == "Preto")
        ) {
            await andar_frente();
        } else if (
            ((Bot.GetComponent<ColorSensor>(sensor_cor_direita_ref).Analog).ToString() == "Vermelho") || //parar na linha de chegada
            ((Bot.GetComponent<ColorSensor>(sensor_cor_esquerda_ref).Analog).ToString() == "Vermelho")
        ) {
            await travar_motor();
        } else {
            await andar_frente(100); //se não parar andar pra frente
        }
    }
}