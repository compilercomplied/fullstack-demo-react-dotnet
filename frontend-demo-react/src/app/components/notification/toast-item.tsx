import { Toastable } from "../../domain/models/ABC";
import { ToastFlavour } from "../../domain/models/notification/flavour";

export const ToastItem = (toast: Toastable) => {

  let flavour;

  switch(toast.flavour) {
    case(ToastFlavour.Alert): flavour = "toast-alert"; break;
    case(ToastFlavour.Notify): flavour = "toast-notify"; break;
    default: flavour = "toast-error";
  }


  return (
    <li>
      <div className={"toast-container " + flavour}>
        <div className="toast-message">
        {toast.message}
        </div>
      </div>
    </li>
  );

}