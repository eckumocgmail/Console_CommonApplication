 
using System.Collections.Generic;
using System.Text;
using System.Xml;

    enum XmlParserMode
    {
        /// <summary>
        /// режим разбора атрибутов
        /// </summary>
        inner, 
        
        /// <summary>
        /// Режим разбора внутреннего текста
        /// </summary>
        outer
    }





    class XmlParser 
    {
        private XmlParserMode Mode { get; set; } = XmlParserMode.outer;


        /*public TypeNode<InputParams> Parse( string xml )
        {
            
            TypeNode<InputParams> rootNode = new TypeNode<InputParams>("root" , new InputParams(), null);
            string text = "";
 
            TypeNode<InputParams> currentNode = null;
            bool tagReaded = false;
            bool keyReaded = false;
            string attrKey = "";
            string attrValue = "";
            for (int i=0; i< xml.Length; i++)
            {
                if (Mode == XmlParserMode.outer)
                {
                    if (xml[i] == '<')
                    {
                        currentNode = new TypeNode<InputParams>("", new InputParams(), currentNode);
                        Mode = XmlParserMode.inner;
                        continue;
                    }
                    else
                    {
                        text += xml[i];
                    }
                }
                else
                {
                    if (xml[i] == ' ' || xml[i] == '>')
                    {
                        if( tagReaded == false)
                        {
                            currentNode.Item.Tag = text;
                            text = "";
                            tagReaded = true;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(attrKey) == false)
                            {
                                currentNode.Item.Attrs[attrKey] = attrValue;
                                attrKey = "";
                                attrValue = "";
                            }
                            
                        }
                    }
                    else
                    {
                        if(xml[i] == '=')
                        {
                            keyReaded = true;
                        }
                        else
                        {
                            if (keyReaded)
                            {
                                attrValue += xml[i];
                            }
                            else
                            {
                                attrKey += xml[i];
                            }
                            keyReaded = false;
                        }
                    }
                }
            }
            return pnode;
        }*/
    }
