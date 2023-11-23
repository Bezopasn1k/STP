#include <iostream> 
#include <list> 
#include <cmath> 
#include <map> 
#include <sstream> 
#include "TMember.h" 
class TPoly {
private:
	std::list<TMember> members;
	void normalize();
public:
	explicit TPoly(int coeff = 0, int degree = 0);
	int GetMaxDegree();
	int GetCoeff(int degree);
	void AddMember(int coeff, int degree);
	void clear();
	[[nodiscard]] TPoly Add(const TPoly& q) const;
	[[nodiscard]] TPoly Mul(const TPoly& q) const;
	[[nodiscard]] TPoly Sub(const TPoly& q) const;
	[[nodiscard]] TPoly Invert() const;
	[[nodiscard]] bool IsEqual(const TPoly& q) const;
	[[nodiscard]] TPoly Differentiate() const;
	[[nodiscard]] int Calculate(int x) const;
	[[nodiscard]] TMember GetElement(int i) const;
	[[nodiscard]] std::string ToString() const;
};