using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05.GestionTareas
{
    public partial class Form1 : Form
    {
        //VARIABLES SCOOPE GLOBAL
        //---------------------------------------------------------------------------------------------------------

        //CONSTRUCTOR
        //---------------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            Reset();
            //Text = "asdfa"; hace lo mismo que this.Text
            this.Text = "List Box"; //Cambia el nombre del formulario
        }
        //FUNCTIONS
        //---------------------------------------------------------------------------------------------------------
        private void Save()
        {
            if (!String.IsNullOrEmpty(display.Text))
            {
                listBoxOutput.Items.Add(display.Text);
                deleteButtonsTrue();
            }
            else
            {
                MessageBox.Show("No has introducido una tarea.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            display.Text = "";
        }

        private void deleteButtonsTrue()
        {
            if (listBoxOutput.Items.Count >= 1)
            {
                buttonDelete.Visible = true;
                buttonEdit.Visible = true;
            }
        }

        private void deleteButtonsFalse()
        {
            if (listBoxOutput.Items.Count < 1)
            {
                buttonDelete.Visible = false;
                buttonEdit.Visible = false;
            }
        }

        private void Clear()
        {
            listBoxOutput.Items.Clear();
            deleteButtonsFalse();
            Reset();
        }

        private void Reset()
        {
            listBoxOutput.Items.Clear();
            display.Text = "";
            deleteButtonsFalse();
        }

        private void eliminarItemListBox()
        {
            if (this.listBoxOutput.SelectedIndex >= 0)
            {
                if (MessageBox.Show("¿Estás seguro de que deseas eliminar la tarea?.", "Alerta", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
                {
                    if (this.listBoxOutput.SelectedIndex >= 0)
                    {
                        this.listBoxOutput.Items.RemoveAt(this.listBoxOutput.SelectedIndex);
                    }
                    if (listBoxOutput.Items.Count <= 0)
                    {
                        this.deleteButtonsFalse();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un elemento a eliminar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void edit()
        {
            if (this.listBoxOutput.SelectedIndex >= 0)
            {
                if (!string.IsNullOrEmpty(listBoxOutput.Items[listBoxOutput.SelectedIndex].ToString()))
                {
                    display.Text = listBoxOutput.Items[listBoxOutput.SelectedIndex].ToString();
                    this.listBoxOutput.Items.RemoveAt(this.listBoxOutput.SelectedIndex);
                    deleteButtonsFalse();
                }
            }
            else
            {
                MessageBox.Show("No has seleccionado ninguna tarea a editar.");
            }
        }
        //EVENTS
        //---------------------------------------------------------------------------------------------------------
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            eliminarItemListBox();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            edit();
        }
    }
} 