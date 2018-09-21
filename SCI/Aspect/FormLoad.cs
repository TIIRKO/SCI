using PostSharp.Aspects;
using System;
using System.Windows.Forms;

namespace SCI.Aspect
{
    [Serializable]
    public class FormLoad : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            /*
            if (args.Instance is SCI.View.Desktop)
                ((View.Desktop)args.Instance).ShowLoading();
            else //if (args.Instance is View.Controles.BaseForm)
                ((View.Controles.BaseForm)args.Instance).ShowLoading();
            */
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            //MessageBox.Show("Sucesso");
        }
        public override void OnException(MethodExecutionArgs args)
        {
            //MessageBox.Show("Erro");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            /*
            if (args.Instance is SCI.View.Desktop)
                ((View.Desktop)args.Instance).HideLoading();
            else //if (args.Instance is View.Controles.BaseForm)
                ((View.Controles.BaseForm)args.Instance).HideLoading();
            */
        }
    }
}
