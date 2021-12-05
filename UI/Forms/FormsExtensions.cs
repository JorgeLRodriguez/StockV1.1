using Services.BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Forms
{
    public static class FormExtensions
    {
        public static void LinkToTranslationServices(this Form thisForm, IUserTranslator userTranslator)
        {
            var subscriberChangeLanguage = thisForm as ILanguageSubscriber;
            if (subscriberChangeLanguage == null)
                throw new ApplicationException(string.Format(
                    "El formulario {0} debe implementar {1} para ser compatible con traducciones", thisForm.Name,
                    typeof(ILanguageSubscriber).Name));

            userTranslator.Subscribe(subscriberChangeLanguage);
            thisForm.FormClosing += (sender, args) => userTranslator.Unsubscribe(subscriberChangeLanguage);
        }
        public static DialogResult ShowInformationDialog(this Form thisForm, ITranslator translator, string key)
        {
            return ShowDialog(thisForm, translator, key, MessageBoxIcon.Information);
        }
        public static DialogResult ShowWarningDialog(this Form thisForm, ITranslator translator, string key)
        {
            return ShowDialog(thisForm, translator, key, MessageBoxIcon.Warning);
        }
        public static DialogResult ShowErrorDialog(this Form thisForm, ITranslator translator, string key)
        {
            return ShowDialog(thisForm, translator, key, MessageBoxIcon.Error);
        }
        private static DialogResult ShowDialog(Form thisForm, ITranslator translator, string key, MessageBoxIcon icon)
        {
            return ShowDialog(thisForm, translator.Translate(key), icon);
        }
        private static DialogResult ShowDialog(Form thisForm, string translatedText, MessageBoxIcon icon)
        {
            return MessageBox.Show(thisForm, translatedText, thisForm.Text, MessageBoxButtons.OK, icon);
        }
        public static System.Collections.ObjectModel.ObservableCollection<T> AsObservable<T>(this System.Collections.Generic.IEnumerable<T> thisEnumerable)
        {
            return new System.Collections.ObjectModel.ObservableCollection<T>(thisEnumerable);
        }
        public static void LinkList<T>(this ListControl thisControl, IEnumerable<T> dataSource, string displayMember, string valueMember)
        {
            thisControl.DataSource = null;
            thisControl.DisplayMember = displayMember;
            thisControl.ValueMember = valueMember;
            thisControl.DataSource = dataSource.AsObservable();
        }
    }
}
