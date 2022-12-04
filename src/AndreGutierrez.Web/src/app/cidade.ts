
export interface GetCidadeList {
  success: boolean,
  error: ApiError,
  list: Cidade[]
}

export interface GetCidade {
  success: boolean,
  error: ApiError,
  value: Cidade
}

export interface PutCidade {
  success: boolean,
  error: ApiError
}


export interface DeleteCidade {
  success: boolean,
  error: ApiError
}

export interface ApiError {
  message: string,
  details: string
}

export interface Cidade {
    id: number;
    nome: string;
    uf: string;
  }