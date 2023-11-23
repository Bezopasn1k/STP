#include <iostream> 
#include <algorithm> 
#include <cmath> 
class TMember {
private:
	int FCoeff;
	int FDegree;
public:
	explicit TMember(int coeff = 0, int degree = 0);
	[[nodiscard]] int GetDegree() const;
	void SetDegree(int degree);
	[[nodiscard]] int GetCoeff() const;
	void SetCoeff(int coeff);
	bool IsEqual(const TMember& q) const;
	[[nodiscard]] TMember Differentiate() const;
	[[nodiscard]] int Calculate(int x) const;
	[[nodiscard]] std::string ToString() const;
};