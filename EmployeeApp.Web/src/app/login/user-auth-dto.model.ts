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
}

export interface AuthResponseDto {
    isAuthSuccessful: boolean;
    errorMessage: string;
    token: string;
}

export interface IdentityResult {
    succeeded: boolean;
    errors: IdentityResultError[];
}

export interface IdentityResultError {
    description: string;
}