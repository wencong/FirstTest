using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Item {
    private string m_name;
    private int m_ID;
    public Item(string name, int id) {
        m_name = name;
        m_ID = id;
    }

    public string name {
        get {
            return m_name;
        }
    }

    public int ID {
        get {
            return m_ID;
        }
    }
}

