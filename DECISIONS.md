# Decisões do Projeto

## Arquitetura
Optei por arquitetura em camadas (Controllers, Services, Domain, Infrastructure)
por ser adequada para o escopo do MVP e de fácil entendimento e manutenção.

## Banco de dados
SQLite para o MVP pela simplicidade de configuração.
Possível migração para PostgreSQL no futuro.

## Notas por lead
Criada entidade separada LeadNote com relacionamento N:1 com Lead,
para manter histórico completo de interações com data de cada registro.

## Autenticação
JWT interno no próprio sistema. Sem API externa de auth,
pois seria complexidade desnecessária para o tamanho do projeto.

## Moeda (Currency)
Campo texto livre. O negócio opera com qualquer moeda,
então não faz sentido limitar com enum.

## Endpoints públicos vs protegidos
- POST /api/leads → público (recebe lead do formulário do site)
- Demais endpoints → protegidos com JWT (painel administrativo)

## Entidades principais
- Lead → dados do cliente
- LeadNote → histórico de notas
- User → autenticação