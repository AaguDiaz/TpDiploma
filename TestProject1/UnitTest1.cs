using Sistema_ACA.Forms.Admin;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
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
            Assert.AreEqual(1, form.tvGrupo.Nodes.Count); // Verificar que se ha añadido un nodo
            Assert.AreEqual("Permiso1", form.tvGrupo.Nodes[0].Text); // Verificar que el nodo tiene el texto correcto
        }
    }
}