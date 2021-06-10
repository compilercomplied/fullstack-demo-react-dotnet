import React, { useContext, useEffect, useState } from "react";
import { ToastCtxt } from "../../contexts/toast";
import { Toastable } from "../../domain/models/ABC";
import { ToastFlavour } from "../../domain/models/notification/flavour";
import { ToastItem } from "./toast-item";
import "./toast.css";

export const ToastBucket = () => {

  const [ toasts, setToasts ] = useState([] as Toastable[]);
  const { state: appErrors } = useContext(ToastCtxt);
  const { dispatch } = useContext(ToastCtxt);


  const cleanUp = () => {

    if (toasts.length >= 0) {
      dispatch({ type:"del" });
      setToasts(toast => toast.slice(1));
    }

  };

  useEffect(() => {

    const notification = appErrors[appErrors.length - 1];
    if (!notification) return;


    const toastBubble = { 
      message: notification.message,
      flavour: ToastFlavour.Error
    };

    setToasts((f) => f.concat(toastBubble));
    setTimeout(() => cleanUp(), 2000);

  }, [ appErrors ]);


  return (
    <div id="notify-root">
      <ul>
        {toasts.map((f) => <ToastItem {...f}/>)}
      </ul>
    </div>
  );

}