# 📄 IDEIA DO PROJETO - CP2 - ADVANCED BUSINESS DEVELOPMENT WITH .NET

Este documento apresenta a proposta do grupo para o projeto de CP2, baseado no desafio real da empresa Mottu.

---

👥 INTEGRANTES DO GRUPO
===========================

- RM557462 - Guilherme Romanholi Santos

---

📘 TÍTULO DO PROJETO
===========================

OndeTáMoto? – Sistema Inteligente de Monitoramento de Motos em Garagens da Mottu

---

🎯 PROBLEMA A SER RESOLVIDO
===========================

A Mottu precisava de uma forma eficiente e em tempo real para controlar a entrada, permanência e saída das motos dentro de suas garagens.  
O processo atual, baseado em planilhas e controles manuais, é falho, suscetível a erros e não oferece a visibilidade necessária para uma operação ágil e precisa.

---

💡 SOLUÇÃO PROPOSTA
===========================

Desenvolvemos o **OndeTáMoto?**, uma solução tecnológica baseada em IoT que automatiza e organiza o controle de motos dentro da garagem da Mottu.

- Cada moto possui uma tag inteligente com identificação única.
- A movimentação da moto é registrada automaticamente.
- Os dados são enviados para um aplicativo mobile com uma interface intuitiva.
- A equipe pode consultar em tempo real o status e localização das motos.
- É possível categorizar motos por finalidade e situação (disponível, manutenção, em uso etc).

Com isso, reduzimos falhas manuais, aumentamos a eficiência e promovemos mais controle sobre a frota da empresa.

---

📐 ENTIDADES PRINCIPAIS
===========================

- **Moto**: placa, modelo, status, posição, finalidade
- **Tag IoT**: identificador, moto vinculada
- **Garagem**: nome, capacidade, localização
- **Movimentação**: entrada, saída, timestamp, status atual
- **Usuário (Operador)**: nome, login, permissões

---

🛠 TECNOLOGIAS E ESTRUTURA
===========================

- .NET 8
- Entity Framework Core com Oracle
- Swagger para documentação da API
- Clean Architecture
- DTOs, MappingConfig, Migrations
- Aplicativo Mobile integrado (futuro)
- Integração com sensores IoT (tag por moto)

---

📌 OBSERVAÇÕES FINAIS
===========================

O projeto OndeTáMoto? foi idealizado para resolver uma dor real da Mottu com inovação, simplicidade e tecnologia.  
Mais do que um sistema de controle, entregamos uma nova forma de pensar a gestão de frotas urbanas.

