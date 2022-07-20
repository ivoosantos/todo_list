# todo_list
Desenvolvimento de lista de tarefas.

# Utilizar o Vue.js
$ npm install vue
Para executar:
$ npm run serve


# API - AspNet Core 3.1

Foi utilizado Entity Framework com linq para ações no banco e o Dapper para montar algumas query's.
No console do gerenciador de pacotes, digite "update-database" para o entity gerar a tabela no banco de dados.
No projeto do back-end tem uma pasta chamada "Migration", o entity usa ela para poder criar a tabela no banco,
pois lá se encontra o script.
O banco de dados utilizado foi o Postgresql usando o gerenciador de banco DBeaver.
