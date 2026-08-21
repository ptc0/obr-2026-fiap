### Sistema de Funções
Funções primárias responsáveis pelo funcionamento e movimentação do robô.


| Função | Descrição | Parametros | Retorno |
|:---|:---|:---:|:---:|
|andar_frente() | Move o robo com velocidade e torque variavel| ```Velocidade``` ```Torque```| -
| voltar() | Gira o robo no proprio eixo 180º| - | -|
| girar() | Gira o robo no angulo desejado | ```Angulo``` | - 
| virar() | Faz uma leve curva sem parar o robo para o lado desejado | ```lado ('E') ou ('D') ``` | -
| virar90 | Realiza uma curva de 90º para o lado desejado | ``` lado ('E') ou ('D')  ```| -
| desviar_obstaculo() | Executa o procedimento de desvio | - | -
| acelaracao_por_angulo() | Acelera o robo com base no angulo dos censores | ``` velocidade_desejada ```| ```velocidade``` 



### Nomenclatura de Sensores

| Nome | Descrição
|:---| ---|
| **me** | Motor Esquerdo
| **md** | Motor Direito
| **sce** | Sensor de cor Esquerda
| **scd** | Sensor de cor Direito
| **scm** | Sensor de cor Central
| **sudt** | Sensor Ultrasônico Direita Traseito
| **sudf** | Sensor Ultrasônico Direita Frontal
| **suet** | Sensor Ultrasônico Esquerda Traseito
| **suef** | Sensor Ultrasônico Esquerda Frontal
| **suf**  | Sensor Ultrasônico Frontal
| **sub**  | Sensor Ultrasônico Inferior 



### Nomenclatura de variaveis

| Nome | Descrição | Tipo
|:---| --- | --- |
| **dbg** | Modo debug | ```boolean``` |
| **vel_padrao** | Velodidade dos motores para frente | ```double``` 
| **vel_padrao_curva** | Velocidade dos motores do lado de fora da curva | ```double``` 
| **vel_padrao_curva2** | Velocidade dos motores do lado de dentro da curva | ```double```
| **delay_exec** | Delay entre cada execução | ```double```
| **tick** | Tempo que a função de curva fica ativa, em ms | ```double```