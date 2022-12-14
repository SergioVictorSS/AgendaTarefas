using System.Linq;
using System.Collections.Generic;
namespace AgendaTarefas
{
    public interface Controller<T>
    {
        T BuscarId(int id);

        List<T> Listar(T busca);
        decimal Inserir(T item);
        void Alterar(T item);
        void Excluir(int id);
    }
}