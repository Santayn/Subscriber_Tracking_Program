using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class FormController
    {
        private static FormController _instance;
        private readonly Stack<Form> _formsStack;

        private FormController() { _formsStack = new Stack<Form>(); }

        public static FormController Instance
        {
            get
            {
                if (_instance == null) _instance = new FormController();
                return _instance;
            }
        }

        public void PushAndClose(Form form)
        {
            _formsStack.Pop().Close();
            _formsStack.Push(form);
            form.Show();
        }

        public void PushAndHide(Form form)
        {
            if (_formsStack.Count > 0)
                _formsStack.Peek().Hide();
            _formsStack.Push(form);
            form.Show();
        }

        public void Pop()
        {
            _formsStack.Pop();
            _formsStack.Peek().Show();
        }
    }
}