using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public interface ISelectable
{
    public bool GetSelected();
    public void Select();

    public void Deselect();
}
