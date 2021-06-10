import Axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { useEffect, useState } from "react";
import { APIParams } from "../../constants/http";
import { APIToastError } from "../../domain/models/api-error";
import { APIError } from "../../domain/models/api/error";
import { SetState } from "../../extensions/react-wrap";
import { Optional } from "../../extensions/types"
import { useMegaphone } from "../megaphone";


// --- Helpers -----------------------------------------------------------------
const buildUri = (root: string, path: string) => {
  return `${root}${path}`;

}

const handleAxiosError = (e: AxiosError): APIToastError => {

  if (e.message === "Network Error") {
    return new APIToastError(`Unable to reach host at ${e.config.url}`, 0);

  }
  else if (e.response?.data) {
    const apiError = e.response.data as APIError;
    return new APIToastError(apiError.message, e.response?.status ?? 0);

  }
  else {
    return new APIToastError(e.message, 0);

  }

}

const handleAPIResponse = <T>(
    apiResponse: (AxiosResponse<T> | APIToastError | AxiosResponse<APIError>),
    setResp: SetState<T>,
    setError: SetState<Optional<APIToastError>>
  ): void => {

  if (apiResponse instanceof APIToastError){
    setError(apiResponse);

  }
  else if ((apiResponse as AxiosResponse<T>)!?.status === 200) {
    setResp((apiResponse as AxiosResponse<T>).data);

  }
  else {
    const apiError = (apiResponse as AxiosResponse<APIError>);
    setError(new APIToastError(apiError.data.message, apiError?.status ?? 0));

  }

};


// --- Verbs -------------------------------------------------------------------
const post = 
  async <T>(uri: string, body:Optional<{}>, config: AxiosRequestConfig)
    : Promise<AxiosResponse<T> | APIToastError> => {

  if(body) {
    return await Axios.post(uri, body, config)
      .then((response: AxiosResponse<T>) => response)
      .catch((e: any) => handleAxiosError(e));

  } else {
    return await Axios.post(uri, config)
      .then((response: AxiosResponse<T>) => response)
      .catch((e: any) => handleAxiosError(e));
  }

}


// -----------------------------------------------------------------------------
type APIHookOut<T> = { 
  response: T, 
  error: Optional<APIToastError>, 
  isLoading: boolean 
};

export const useAPI = 
  <T>(params: APIParams, trigger: boolean = true): APIHookOut<T>  => {

  const [ response, setResponse ] = useState({} as T);
  const [ error, setError ] = useState(undefined as Optional<APIToastError>);
  const [ isLoading, setLoading ] = useState(false);

  useMegaphone(error);

  const { root, path, headers, body } = params;


  useEffect(() => {
    if (!trigger) return;

    setLoading(true);


    const uri = buildUri(root, path);

    const config: AxiosRequestConfig = { 
      headers: headers,
    };


    switch (params.verb) {
      case "POST": 
        (async () => {
          const resp = await post<T>(uri, body, config); 
          handleAPIResponse(resp, setResponse, setError);
        })();
        break;

      default: throw Error(`useAPI malformed execution ${JSON.stringify(params)}`);

    }

    setLoading(false);

  // eslint-disable-next-line
  }, [  trigger ]);

  return { response, error, isLoading };

}
