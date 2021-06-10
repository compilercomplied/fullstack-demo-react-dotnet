


class APIBackendConfig {

  root: string = process.env.REACT_APP_API_ROOT ?? "";

}

export type APIPath = "/translation";

export const apiconfig = new APIBackendConfig();