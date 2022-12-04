
export interface GetEstadoList {
  success: boolean,
  error: ApiError,
  list: Estado[]
}

export interface ApiError {
  message: string,
  details: string
}

export interface Estado {
    uf: string;
}