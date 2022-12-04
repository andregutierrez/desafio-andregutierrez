import { Cidade } from "./cidade"

export interface GetPessoaList {
  success: boolean,
  error: ApiError,
  list: Pessoa[]
}

export interface GetPessoa {
  success: boolean,
  error: ApiError,
  value: Pessoa
}

export interface PutPessoa {
  success: boolean,
  error: ApiError
}


export interface DeletePessoa {
  success: boolean,
  error: ApiError
}

export interface ApiError {
  message: string,
  details: string
}

export interface Pessoa {
    id: number;
    nome: string;
    cpf: string;
    idade: number;
    cidade: Cidade;
  }