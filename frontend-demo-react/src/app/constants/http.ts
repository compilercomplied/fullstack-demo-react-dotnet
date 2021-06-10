import { Optional } from "../extensions/types";


export type HttpVerb = "GET" | "POST" |  "PUT" | "DEL";


export type HttpHeader = { }

export type APIParams = {

  root: string,
  path: string,
  verb: HttpVerb,
  body?: Optional<{}>,
  headers?: Optional<HttpHeader>,

}