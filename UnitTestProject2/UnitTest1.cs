using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sistema_ACA.Forms.Admin;
using System;
using System.Windows;
using System.Windows.Forms;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void TestMethod1()
        {
            // Preparar
            var form = new Grupos(); // Reemplaza 'TuFormulario' con el nombre de tu formulario
            var clbPermisos = new CheckedListBox();
            clbPermisos.Items.Add("Permiso1");
            clbPermisos.Items.Add("Permiso2");
            form.Controls.Add(clbPermisos);

            // Ejecutar
            clbPermisos.SetItemChecked(0, true); // Marcar el primer permiso

            // Verificar
            Assert.AreEqual(1, form.GrupoVer().Nodes.Count); // Verificar que se ha añadido un nodo
            Assert.AreEqual("Permiso1", form.GrupoVer().Nodes[0].Text); // Verificar que el nodo tiene el texto correcto
        }

        [TestMethod]
        public void TestCaso1()
        {
            // Preparar
            var form = new Grupos();
            var clbPermisos = new CheckedListBox();
            clbPermisos.Items.Add("Permiso1");
            form.Controls.Add(clbPermisos);
            

            // Ejecutar
            if (clbPermisos.Items.Count > 0) // Verificar si hay elementos en clbPermisos.Items
            {
                var e = new ItemCheckEventArgs(clbPermisos.Items.Count - 1, CheckState.Indeterminate, CheckState.Unchecked);
                form.clbPermisos_ItemCheck(clbPermisos, e);
            }

            // Verificar
            Assert.AreEqual(0, form.GrupoVer().Nodes.Count); // No se debería modificar tvGrupo
        }

        [TestMethod]
        public void TestCaso2()
        {
            // Preparar
            var form = new Grupos();
            var clbPermisos = new CheckedListBox();
            clbPermisos.Items.Add("Permiso1");
            form.Controls.Add(clbPermisos);
            var e = new ItemCheckEventArgs(0, CheckState.Checked, CheckState.Unchecked);

            // Ejecutar
            if (clbPermisos.Items.Count > 0) // Verificar si hay elementos en clbPermisos.Items
            {
                form.clbPermisos_ItemCheck(clbPermisos, e);
            }

            // Verificar
            Assert.AreEqual(0, form.GrupoVer().Nodes.Count); // No se debería modificar tvGrupo
        }

        [TestMethod]
        public void TestCaso3()
        {
            // Preparar
            var form = new Grupos();
            var clbPermisos = new CheckedListBox();
            clbPermisos.Items.Add("Permiso1");
            form.Controls.Add(clbPermisos);
            form.GrupoVer().Nodes.Add("Permiso1");
            var e = new ItemCheckEventArgs(0, CheckState.Checked, CheckState.Unchecked);

            // Ejecutar
            if (clbPermisos.Items.Count > 0) // Verificar si hay elementos en clbPermisos.Items
            {
                form.clbPermisos_ItemCheck(clbPermisos, e);
            }

            // Verificar
            Assert.AreEqual(1, form.GrupoVer().Nodes.Count); // No se debería modificar tvGrupo
        }
        
        [TestMethod]
        public void TestCaso5()
        {
            // Preparar
            var form = new Grupos();
            var clbPermisos = new CheckedListBox();
            clbPermisos.Items.Add("Permiso1");
            form.Controls.Add(clbPermisos);
            var e = new ItemCheckEventArgs(0, CheckState.Unchecked, CheckState.Checked);

            // Ejecutar
            if (clbPermisos.Items.Count > 0) // Verificar si hay elementos en clbPermisos.Items
            {
                form.clbPermisos_ItemCheck(clbPermisos, e);
            }

            // Verificar
            Assert.AreEqual(0, form.GrupoVer().Nodes.Count); // No se debería modificar tvGrupo
        }

        [TestMethod]
        public void TestCaso6()
        {
            // Preparar
            var form = new Grupos();
            var clbPermisos = new CheckedListBox();
            clbPermisos.Items.Add("Permiso1");
            form.Controls.Add(clbPermisos);
            form.GrupoVer().Nodes.Add("Permiso1");
            var e = new ItemCheckEventArgs(0, CheckState.Unchecked, CheckState.Checked);

            // Ejecutar
            if (clbPermisos.Items.Count > 0) // Verificar si hay elementos en clbPermisos.Items
            {
                form.clbPermisos_ItemCheck(clbPermisos, e);
            }

            // Verificar
            Assert.AreEqual(1, form.GrupoVer().Nodes.Count); // Se debería eliminar el nodo correspondiente de tvGrupo
        }*/
    }
}
