#include "TPoly.h"

TPoly::TPoly(int coeff, int degree) {
    if (coeff != 0) {
        members.emplace_back(coeff, degree);
    }
}

int TPoly::GetMaxDegree() {
    int maxDegree = 0;
    for (const TMember &member: members) {
        if (member.GetDegree() > maxDegree) {
            maxDegree = member.GetDegree();
        }
    }
    return maxDegree;
}

int TPoly::GetCoeff(int degree) {
    int coeff = 0;
    for (const TMember &member: members) {
        if (member.GetDegree() == degree) {
            coeff = member.GetCoeff();
            break;
        }
    }
    return coeff;
}

void TPoly::AddMember(int coeff, int degree) {
    members.emplace_back(coeff, degree);
}

void TPoly::clear() {
    members.clear();
}

TPoly TPoly::Add(const TPoly &q) const {
    TPoly result;
    result.members = members;
    for (const TMember &member: q.members) {
        result.members.push_back(member);
    }
    result.normalize();
    return result;
}

TPoly TPoly::Mul(const TPoly &q) const {
    TPoly result;
    for (const TMember &member1: members) {
        for (const TMember &member2: q.members) {
            int newCoeff = member1.GetCoeff() * member2.GetCoeff();
            int newDegree = member1.GetDegree() + member2.GetDegree();
            result.AddMember(newCoeff, newDegree);
        }
    }
    result.normalize();
    return result;
}

TPoly TPoly::Sub(const TPoly &q) const {
    TPoly result;
    result.members = members;
    for (const TMember &member: q.members) {
        result.AddMember(-member.GetCoeff(), member.GetDegree());
    }
    result.normalize();
    return result;
}

TPoly TPoly::Invert() const {
    TPoly result;
    result.members = members;
    for (TMember& member : result.members) {
        member.SetCoeff(-member.GetCoeff());
    }
    return result;
}

bool TPoly::IsEqual(const TPoly &q) const {
    if (members.size() != q.members.size()) {
        return false;
    }
    auto it1 = members.begin();
    auto it2 = q.members.begin();
    while (it1 != members.end() && it2 != q.members.end()) {
        if (!it1->IsEqual(*it2)) {
            return false;
        }
        ++it1;
        ++it2;
    }
    return true;
}

TPoly TPoly::Differentiate() const{
    TPoly result;
    for (const TMember& member : members) {
        TMember derivative = member.Differentiate();
        result.AddMember(derivative.GetCoeff(), derivative.GetDegree());
    }
    result.normalize();
    return result;
}

int TPoly::Calculate(int x) const {
    int value = 0;
    for (const TMember& member : members) {
        value += member.Calculate(x);
    }
    return value;
}

TMember TPoly::GetElement(int i) const {
    if (i >= 0 && i < members.size()) {
    auto it = std::next(members.begin(), i);
        return *it;
    }
    return TMember(0, 0);
}

std::string TPoly::ToString() const {
    std::stringstream ss;
    bool firstTerm = true;
    for (const TMember& member : members) {
        if (member.GetCoeff() != 0) {
        if (!firstTerm) {
            if (member.GetCoeff() > 0) {
                ss << " + " << member.ToString();
            } else {
                ss << " - " << member.ToString().erase(0, 1);
            }
        } else {
            ss << member.ToString();
        }
            firstTerm = false;
        }
    }
    if (firstTerm) {
        ss << "0";
    }
    return ss.str();
}

void TPoly::normalize() {
    members.remove_if([](const TMember &member) { return member.GetCoeff() == 0; });
    std::map<int, int> degreeToCoeff;
    for (const TMember &member : members) {
        int degree = member.GetDegree();
        int coeff = member.GetCoeff();
        degreeToCoeff[degree] += coeff;
    }
    members.clear();
    for (const auto &entry : degreeToCoeff) {
        int degree = entry.first;
        int coeff = entry.second;
        members.emplace_back(coeff, degree);
    }
    members.sort([](const TMember &a, const TMember &b) { return
    a.GetDegree() > b.GetDegree(); }); 
}
