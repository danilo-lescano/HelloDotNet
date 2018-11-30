# tacertoforms
Formulários de criação de fase no jogo TaCerto


# Informações sobre o Unit of Work
"Maintains a **1 list of objects** affected by a **2 business transaction** and **3 coordinates the writing out of changes and the resolution of concurrency problems**."

The "list of objects" are the **1 repositories**, the "business transactions" are the **2 repository-specific business rules to retrieve data**, and the "coordination of the writing and concurrency problems" are through the **3 DbContext**. 


Qual a utilidade em usar o padrão Unit Of Work ?

* Gerenciar as transações;
* Ordenar o CRUD no banco de dados;
* Impedir a concorrência (duplicação de atualizações);
* Usar somente uma instância do contexto por requisição.

# Entity Framework
