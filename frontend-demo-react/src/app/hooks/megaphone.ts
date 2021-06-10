import { useContext, useEffect } from "react";
import { ToastCtxt } from "../contexts/toast";
import { Optional } from "../extensions/types";
import { Toastable } from "../domain/models/ABC";

export const useMegaphone = (toast: Optional<Toastable>): void => {

  const { dispatch } = useContext(ToastCtxt);

  useEffect(() => {

    if(!toast) return;

    dispatch({ type: "add",  payload: toast });

  // eslint-disable-next-line
  }, [ toast ]);

}