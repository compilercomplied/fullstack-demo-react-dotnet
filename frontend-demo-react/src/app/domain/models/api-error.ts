import { BaseError } from "./ABC";

export class APIToastError extends BaseError {

  constructor(message: string, httpcode: number = 0) {

    const msg = (httpcode === 0) ? message : `${httpcode} - ${message}`;
    super(msg);

  }

}