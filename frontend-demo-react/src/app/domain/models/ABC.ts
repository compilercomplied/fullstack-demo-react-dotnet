import { ToastFlavour } from "./notification/flavour";

export abstract class Toastable {

  protected constructor(
    public message:string, 
    public flavour: ToastFlavour) { 

  }

}

export abstract class BaseError extends Toastable { 

  protected constructor(message: string) { 
    super(message, ToastFlavour.Error); 
  }

}