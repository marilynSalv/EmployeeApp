export interface UserAuthDto {
    username: string;
    password: string;
}

export interface RegisterDto {
    username: string;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    zipCode: string;
    isManager: boolean;
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