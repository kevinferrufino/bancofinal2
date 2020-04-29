﻿using BL.BancoSangre;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.BancoSangre
{
    public partial class FormAgregar : Form
    {
        DonantesBL _donantes;

        public FormAgregar()
        {
            InitializeComponent();

            _donantes = new DonantesBL();
            listaDonantesBindingSource.DataSource = _donantes.ObtenerDonantes();

        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {

        }

        private void listaDonantesBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void listaDonantesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void identidadLabel_Click(object sender, EventArgs e)
        {

        }

        private void identidadTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void direccionLabel_Click(object sender, EventArgs e)
        {

        }

        private void direccionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fechaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fechaLabel_Click(object sender, EventArgs e)
        {

        }

        private void listaDonantesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaDonantesBindingSource.EndEdit();
            var donante = (Donantes)listaDonantesBindingSource.Current;

            var resultado = _donantes.GuardarDonante(donante);

            if (resultado.Exitoso == true)
            {
                listaDonantesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }                

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _donantes.AgregarDonante();
            listaDonantesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;

            toolStripButtonCancelar.Visible = !valor;

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿¡Desea eliminar el registro del donante!?", "ELIMINAR", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }                
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _donantes.EliminarDonante(id);

            if (resultado == true)
            {
                listaDonantesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eleminar el donante");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }
    }
}
