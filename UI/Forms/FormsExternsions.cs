using Services.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Forms
{
    public static class FormExtensions
    {
        public static void EnlazarmeConServiciosDeTraduccion(this Form thisForm, IUserTranslator traductorUsuario)
        {
            var subscriptorCambioIdioma = thisForm as ILanguageSubscriber;
            if (subscriptorCambioIdioma == null)
                throw new ApplicationException(string.Format(
                    "El formulario {0} debe implementar {1} para ser compatible con traducciones", thisForm.Name,
                    typeof(ILanguageSubscriber).Name));

            traductorUsuario.Subscribe(subscriptorCambioIdioma);
            thisForm.FormClosing += (sender, args) => traductorUsuario.Unsubscribe(subscriptorCambioIdioma);
        }
        public static DialogResult MostrarDialogoInformacion(this Form thisForm, ITranslator traductor, string constanteDeTexto)
        {
            return MostrarDialogo(thisForm, traductor, constanteDeTexto, MessageBoxIcon.Information);
        }
        public static DialogResult MostrarDialogoAdvertencia(this Form thisForm, ITranslator traductor, string constanteDeTexto)
        {
            return MostrarDialogo(thisForm, traductor, constanteDeTexto, MessageBoxIcon.Warning);
        }
        public static DialogResult MostrarDialogoError(this Form thisForm, ITranslator traductor, string constanteDeTexto)
        {
            return MostrarDialogo(thisForm, traductor, constanteDeTexto, MessageBoxIcon.Error);
        }
        private static DialogResult MostrarDialogo(Form thisForm, ITranslator traductor, string constanteDeTexto, MessageBoxIcon icono)
        {
            return MostrarDialogo(thisForm, traductor.Translate(constanteDeTexto), icono);
        }
        private static DialogResult MostrarDialogo(Form thisForm, string textoTraducido, MessageBoxIcon icono)
        {
            return MessageBox.Show(thisForm, textoTraducido, thisForm.Text, MessageBoxButtons.OK, icono);
        }
        public static System.Collections.ObjectModel.ObservableCollection<T> AsObservable<T>(this System.Collections.Generic.IEnumerable<T> thisEnumerable)
        {
            return new System.Collections.ObjectModel.ObservableCollection<T>(thisEnumerable);
        }

        public static void EnlazarListado<T>(this ListControl thisControl, IEnumerable<T> dataSource, string displayMember, string valueMember)
        {
            thisControl.DataSource = null;
            thisControl.DisplayMember = displayMember;
            thisControl.ValueMember = valueMember;
            thisControl.DataSource = dataSource.AsObservable();
        }
    }
}
