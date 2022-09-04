

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// 
/// </summary>
public class TreeViewService
{


    


    //ascendant - восходящее преобразование
    public List<global::Tree> CreateAscendant(List<Type> Items, Func<Type, Type> GetParent)
    {


        //узлы сключом по HashCode обьекта находящегося в нём
        Dictionary<string, global::Tree> Map = new Dictionary<string, global::Tree>();

        foreach (Type Item in Items)
        {
            Map[Item.FullName] = new global::Tree()
            {
                Item = new DictionaryTable()
                {
                    Name = Item.Name,
                    Item = Item
                }
            };

        }



        /*
        foreach (var p in Map)
        {
            global::Tree Node = p.Value;
            
            Type Parent = GetParent(ReflectionService.GetValueFor((Type)Node.Item, "Item"));
            if (Parent != null )
            {
                if (Map.ContainsKey(Parent.FullName))
                {
                    Api.Utils.Info("Найден тип " + Parent.FullName);
                    Tree ParentNode = Map[Parent.FullName];
                    //ParentNode.Append(Node);
                    Node.SetParent(ParentNode);
                }
                else
                {
                    Api.Utils.Info("Не доступен тип "+Parent.FullName);
                }
                    
            } 
        }*/

        List<global::Tree> roots = (from p in Map.Values where p.Parent == null select p).ToList();
        return roots;
    }

    public IEnumerable<Type> GetHierDictionaries(DbContext db)
    {

        return db.GetEntitiesTypes().ToList().Where(t => TypeUtils.IsHierDictinary(t)).ToList();
    }

    public Tree CreateDescendant(object viewItem, Func<object, Tree> create, Func<object, List<object>> getChildren)
    {
        Tree pnode = create(viewItem);
        foreach (var pchild in getChildren(viewItem))
        {
            pnode.Children.Add(CreateDescendant(pchild, create, getChildren));
        }
        return pnode;
    }



    public List<global::Tree> CreateAscendantByHash<T>(IEnumerable<T> Items, Func<T, T> GetParent)
    {
        //узлы сключом по HashCode обьекта находящегося в нём
        Dictionary<int, global::Tree> Map = new Dictionary<int, global::Tree>();

        foreach (T Item in Items)
        {
            Map[Item.GetHashCode()] = new global::Tree()
            {
                Item = new DictionaryTable()
                {
                    Name = Item.GetType().Name,
                    Item = Item
                }
            };

        }
        foreach (var p in Map)
        {
            global::Tree Node = p.Value;
            /*
            T Parent = GetParent((T)Node.Item.Item);
            if (Parent != null)
            {
                if (Map.ContainsKey(Parent.GetHashCode()))
                {
                    Tree ParentNode = Map[Parent.GetHashCode()];
                    //ParentNode.Append(Node);
                    Node.SetParent(ParentNode);
                }
                else
                {
                    Api.Utils.Info("Не доступен тип " + Parent.GetType().Name);
                }

            }*/
        }

        List<global::Tree> roots = (from p in Map.Values where ((dynamic)(p.Item)).ParentID == null select p).ToList();
        return roots;
    }


    //[SelectControlAttribute]
    public global::Tree CreateFromHierDictionary(dynamic list)
    {
        Dictionary<int, global::Tree> map2 = new Dictionary<int, global::Tree>();
        Dictionary<int, object> map = new Dictionary<int, object>();
        List<global::Tree> nodes = new List<global::Tree>();


        foreach (dynamic record in list)
        {
            map[record.ID] = record;
            nodes.Add(map2[record.ID] = new global::Tree() { Item = record, Title = record.Name, Draggable = false });
        }
        foreach (global::Tree pnode in nodes.ToArray())
        {
            int? pid = ((dynamic)(pnode.Item)).ParentID;
            if (pid != null)
            {
                pnode.SetParent(map2[(int)pid]);
            }
        }
        List<Tree> roots = (from p in nodes where ((dynamic)(p.Item)).ParentID == null || ((dynamic)(p.Item)).ParentID == p.Item.Casts<HierDictionary>().ID select p).ToList();
        if (roots.Count == 1)
        {
            return roots.First();
        }
        else if (roots.Count > 0)
        {
            var root = new Tree();
            root.Children = nodes.ToList<ViewNode>();
            return root;
        }
        else
        {
            var root = new Tree();
            root.Children = roots.ToList<ViewNode>();
            return root;
        }


    }
}


public class TreeViewServiceTest: TestingElement
{
    public override List<string> OnTest()
    {
        throw new NotImplementedException($"{GetType().GetTypeName()}");
    }
}