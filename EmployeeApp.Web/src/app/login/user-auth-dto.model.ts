export interface UserAuthDto {
    email: string;
    password: string;
}

export interface RegisterDto {
    username: string;
    email: string;
    password: string;
}

export interface AuthResponseDto {
    isAuthSuccessful: boolean;
    errorMessage: string;
    token: string;
}

export interface IdentityResult {
    succeeded: boolean;
    errors: any[];
}