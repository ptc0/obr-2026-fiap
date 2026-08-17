<!-- Adicionar nome e explicação. -->

## Descrição de funcionamento

### Sistema de funçoes
Funções primárias responsáveis pelo funcionamento e movimentação do robô.


| Funcão | Descrição | Parametros | Retorno |
|:---|:---:|:---:|:---:|
|andar_frente() | move o robo com velocidade e torque variavel| ```Velocidade``` , ```Torque```| ----
| voltar() | Gira o robo no proprio eixo 180º| ---- | ----|
| girar() | Gira o robo no angulo desejado | ```Angulo``` | ---- 
| virar() | faz uma leve curva sem parar o robo para o lado desejado | ```lado ('E') ou ('D') ``` | ----
| virar90 | Realiza uma curva de 90º para o lado desejado | ``` lado ('E') ou ('D')  ```| ----
| desviar_obstaculo() | executa o procedimento de desvio | ---- | ----
| acelaracao_por_angulo() | acelera o robo com base no angulo dos censores | ``` velocidade_desejada ```| ```velocidade``` 



### Sensores e botões

| Nome | Descrição
|:---| ---:|
| md | motor direito
| me | motor esquerdo
| sce | sensor de cor esquerdo
| scd | sensor de cor deireito
| scm | sensor de cor do meio
| sudt | sensor ultrasonico deireito traseito
| sudf | sensor ultrasonico deireito frontal
| suet | sensor ultrasonico esquerdo traseito
| suef | sensor ultrasonico esquerdo frontal
| suf  | sensor ultrasonico frontal
| sub  | sensor ultrasonico chão 