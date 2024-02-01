import { EmployeeBaseDto } from "../employees/employee.model";

export interface UserAuthDto {
    username: string;
    password: string;
}

export interface RegisterDto extends EmployeeBaseDto, UserAuthDto {
}

export interface AuthResponseDto {
    isAuthSuccessful: boolean;
    errorMessage: string;
    token: string;
    refreshToken: string;
}

export interface IdentityResult {
    succeeded: boolean;
    errors: IdentityResultError[];
}

export interface IdentityResultError {
    description: string;
}

export interface RefreshTokenDto {
    token: string;
    refreshToken: string;
}

export enum LocalStorageKeys {
    Token = 'token',
    RefreshToken = 'refreshToken',
}
