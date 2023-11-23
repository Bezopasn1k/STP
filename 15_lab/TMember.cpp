#include "TMember.h"

TMember::TMember(int coeff, int degree) {
    FCoeff = coeff;
    FDegree = degree;
}

int TMember::GetDegree() const {
    return FDegree;
}

void TMember::SetDegree(int degree) {
    FDegree = degree;
}

int TMember::GetCoeff() const {
    return FCoeff;
}

void TMember::SetCoeff(int coeff) {
    FCoeff = coeff;
}

bool TMember::IsEqual(const TMember &q) const {
    return (FDegree == q.FDegree) && (FCoeff == q.FCoeff);
}

TMember TMember::Differentiate() const {
    TMember derivative(FCoeff * FDegree, std::max(0, FDegree - 1));
    return derivative;
}

int TMember::Calculate(int x) const {
    return FCoeff * static_cast<int>(pow(x, FDegree));
}

std::string TMember::ToString() const {
    std::string result = std::to_string(FCoeff);
    if (FDegree > 0) {
    result += "x^" + std::to_string(FDegree);
    }
    return result;
} 
