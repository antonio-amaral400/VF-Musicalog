# EN
## Assumptions:
	- There is no concept of user / login.
	- Hence, the catalog is not for each user but generic / public.
	- It was assumed that artists and the album names could contain special characters (namely accents) making those fields nvarchar.
	- It was assumed that 100 characters were enough for the album's name.
	- It was assumed that 150 characters were enough for the artist's name.
	- It was assumed that 50 characters were enough for the label.
	- It was assumed that creating the artist table would be a plus since it would provide consistency and the possibility for more data relative to the artist. If it was not considered a plus, instead of a new table and a FK from Album table to the Artist table it would only be created a column nvarchar(150).
	- Since it was not requested a CRUD for the Artists, these need to be altered directly at DB.
	- Artists Id was considered it could reach millions so it was chosen the value int (maximum value of int is 2,147,483,647).
	- It was assumed that creating the Label table would be a plus since it would provide consistency and the possibility for more data relative to the Label. If it was not considered a plus, instead of a new table and a FK from Album table to the Label table it would only be created a column nvarchar(50).
	- Since it was not requested a CRUD for the Label, these need to be altered directly at DB.
	- Label Id was considered it could reach thousands so it was chosen the value smallint (maximum value of smallint is 32,767).
	- It was assumed that creating the AlbumType table would be a plus since it would provide consistency. If it was not considered a plus, instead of a new table and a FK from Album table to the AlbumType table it would only be created a column varchar(10).
	- Since it was not requested a CRUD for the AlbumType, these need to be altered directly at DB.
	- AlbumType Id was considered it could would only reach low numbers so it was chosen the value tinyint (maximum value of tinyint is 255).
	- It was assumed that a representation of the ordering is all that is needed, ignoring the UX part. The "a" and "d" by the side of the columns represents which column is being ordered and if the order is ascending or descending respectively.
	
## Notes:
	- The InsertOrUpdate screen's design was made to underline that I know the basics of bootstrap and not for aesthetic reasons.
	- There is a config in WCF that lets the admin choose if the data is retrieved as is from EntityFramework default behaviour or use cache. I still thought about implementing a timeout in cache but, honestly, I did not think it would make a positive influence in the test.
	- In order to create the initial database there is a file inside the project GenericProjectTests called 'SQL Initializer.txt'.
	- I did not upgrade any of the scripts or css's of the project (namely bootstrap).
	- The key requested for the number of results in a page is called NumberOfAlbumsPerPage.

# PT
## Assumpções:
	- Não há a noção de user / login.
	- Por consequência o catálogo não é ao user mas sim partilhado.
	- Foi assumido que tanto artistas como nomes dos álbuns podiam ter caracteres especiais (nomeadamente acentos) necessitando de campos nvarchar em BD.
	- Foi assumido que 100 caracteres chegavam para o nome dos álbuns.
	- Foi assumido que 150 caracteres chegavam para o nome do artista.
	- Foi assumido que 50 caracteres chegavam para o nome da distribuidora.
	- Foi assumido que criar a tabela artista seria uma mais valia por questão de consistência e possível expansão dos dados relativos ao artista. Caso não fosse considerada uma mais valia, em vez de uma nova tabela e uma FK da tabela Álbuns para a tabela Artistas seria criada apens um campo nvarchar(150).
	- Como não foi pedida um CRUD para o Artista estes terão de ser alterados directamente em BD.
	- Id do Artista foi considerado que poderia chegar aos milhões e por isso foi escolhido int (valor máximo de um campo int 2,147,483,647).
	- Foi assumido que criar a tabela distribuidora seria uma mais valia por questão de consistência e possível expansão dos dados relativos à distribuidora. Caso não fosse considerada uma mais valia, em vez de uma nova tabela e uma FK da tabela Álbuns para a tabela Distribuidora seria criada apens um campo nvarchar(50).
	- Como não foi pedida um CRUD para o distribuidora estes terão de ser alterados directamente em BD.
	- Id da distribuidora foi considerado que poderia chegar aos milhares e por isso foi escolhido smallint (valor máximo de um campo smallint 32,767).
	- Foi assumido que criar a tabela tipo seria uma mais valia por questão de consistência. Caso não fosse considerada uma mais valia, em vez de uma nova tabela e uma FK da tabela Álbuns para a tabela Tipo seria criada apens um campo varchar(10).
	- Como não foi pedida um CRUD para o tipo estes terão de ser alterados directamente em BD.
	- Id do tipo foi considerado que poderia iria ficar pelas unidades mesmo desenvolvendo novas tecnologias para o tipo e por isso foi escolhido tinyint (valor máximo de um campo tinyint 255).
	- Somente seria necessária a indicação da ordenação e não a preocupação com o aspecto da mesma. O "a" ou "d" ao lado das colunas representa qual a coluna de ordenação e se esta é ascendente ou descendente respectivamente.

## Notas:
	- A escolha de design do ecrã de insertOrUpdate foi feita com a intenção de mostrar que percebo como funciona o básico de bootstrap e não por razões estéticas.
	- Foi criada uma configuração no WCF que permite escolher se os dados são tratados como default do EntityFramework ou se é usado um sistema simples de cache. Ainda pensei em usar uma cache com timeout mas achei que não ia trazer mais valia para o teste em causa.
	- Para criar a base de dados inicial existe um ficheiro no projecto GenericProjectTests com o nome 'SQL Initializer.txt'.
	- Não fiz o upgrade a nenhuma das versões de scripts ou css's do projecto (nomeadamente bootstrap).
	- A chave pedida com o número de resultados na página é NumberOfAlbumsPerPage.
