import { HttpVerb, APIParams } from "../../../constants/http";
import { Optional } from "../../../extensions/types";
import { useAPI } from "../../../hooks/http/api";
import { useMegaphone } from "../../../hooks/megaphone";
import { APIToastError } from "../../../domain/models/api-error";
import { apiconfig, APIPath } from "../configuration";

export type QTResponse = {

  text: string;

}
type QTResponseWrap = { 
  response:QTResponse, error: Optional<APIToastError> 
}

export type QTRequest = {

  sourceLanguage: string;
  targetLanguage: string;
  text: string;

}

const shouldTrigger = (body: QTRequest, ): boolean => 
  (!!body.sourceLanguage)
  && (!!body.targetLanguage)
  && (!!body.text);


export const useQTAPI = (body: QTRequest, trigger: boolean): QTResponseWrap => {

  const isTriggered = shouldTrigger(body) && trigger;

  const params = buildBaseConfig("/translation", "POST");
  params.body = body;

  const { response, error } = useAPI<QTResponse>(params, isTriggered);
  useMegaphone(error);

  return { response, error };

};

// --- Helpers -----------------------------------------------------------------
function buildBaseConfig(path: APIPath, verb: HttpVerb): APIParams {

  return {

    verb: verb,
    path: path,
    root: apiconfig.root,

  };

}