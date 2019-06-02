# Batalha Naval
Jogo desenvolvido em Unity, para a matéria de Experiência Criativa

## Membros
* Murilo Ghighatti
* Bruno Silva Freire
* Lucas Maia
* André Terencio
## Features
* Feito em 3D
* Animações
* Multiplayer local
* GUI:
  * Material Design
  * HUD com estatísticas do jogo
* SFX
* VFX
## Implementação
O jogo se passa em uma única cena, e inicia quando ambos os jogadores apertam o botão designado para start.  
Ele é gerenciado por um GameManager, que contém todas as informações sobre a simulação, e coordena os players em relação a qual vez é a de quem.  
Cada navio é um implementado como um Prefab, que é instanciado a partir do "Deck" de um player, que é a lista de navios que ele tem disponível.  

![](https://raw.githubusercontent.com/jbn-puc/BatalhaNaval/master/Diagram.png)
