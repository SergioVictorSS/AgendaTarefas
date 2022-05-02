<div >

<p  style='text-align:center'><span lang=PT-BR>PROJETO
AGENDA DE TAREFAS</span></p>

<p  style='text-indent:-.25in'><span lang=PT-BR>1.<span
style='font:7.0pt "Times New Roman"'></span></span><span
lang=PT-BR>Principais features:</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Cadastrar diferentes níveis de prioridade para
as tarefas, podendo ser identificadas por cores de tag indicadas pelo usuário;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Cadastrar tarefas, informando código, descrição,
status, prioridade e data de entrega;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Editar tarefas já cadastradas, por meio do
respectivo botão na listagem de tarefas;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Marcar tarefas como “Concluída”, através do
botão “Concluir” na listagem de tarefas;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Excluir tarefas, por meio do respectivo botão na
listagem de tarefas;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Consultar tarefas, filtrando por prioridade,
código, nome, prazo e status;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Ordenar tarefas de acordo com as colunas por
meio dos links de sort nos títulos das colunas;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Consultar prioridades, por meio do botão
“Cadastro de prioridades”, com os respectivos filtros disponíveis;</span></p>

<p  style='margin-left:.75in;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Editar prioridades na mesma tela citada
anteriormente;</span></p>

<p  style='text-indent:-.25in'><span
lang=PT-BR>2.<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Configurações necessárias ao funcionamento:</span></p>

<p  style='margin-left:53.5pt;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Rodar os scripts na pasta “Banco” (\AgendaTarefas\AssembleShop\Banco),
na ordem especificada (de acordo com o número antes do nome do script) em uma
database;</span></p>

<p  style='margin-left:53.5pt;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Informar o endereço do servidor e a database na
connectionString do web.config (\AgendaTarefas\AssembleShop\web.config). Por
default, tais campos estão definidos da seguinte forma: “</span><span
lang=PT-BR style='font-size:9.5pt;line-height:107%;font-family:Consolas;
color:blue'>Data Source=localhost;Initial Catalog=AgendaTarefas;</span><span
lang=PT-BR> ”. Trocar a data source para o endereço do servidor do banco de
dados que contém a base (Initial Catalog) onde os scripts foram executados;</span></p>

<p  style='margin-left:53.5pt;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>O projeto está configurado para rodar em modo de
debug e deve ser rodado pela página de início denominada </span><span
lang=PT-BR style='font-size:9.5pt;line-height:107%;font-family:Consolas;
color:blue'>FrmAgendaTarefasInicio</span><span lang=PT-BR> , pois é através
desta que se dá toda a navegação do projeto;</span></p>

<p class=MsoListParagraphCxSpLast style='margin-left:53.5pt;text-indent:-.25in'><span
lang=PT-BR style='font-family:Symbol'>·<span style='font:7.0pt "Times New Roman"'>
</span></span><span lang=PT-BR>Algumas páginas de cadastro abrem através de
pop-up, por isso é necessário que o navegador utilizado permita a visualização
destes.</span></p>

</div>

</body>
