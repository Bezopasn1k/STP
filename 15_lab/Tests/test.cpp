#include "pch.h"
#include "gtest/gtest.h"
#include "../TPoly/TMember.h"

class TMemberTest : public ::testing::Test {
protected:
	void SetUp() override {}
	void TearDown() override {}
};


TEST_F(TMemberTest, Constructor) {
	TMember member1(6, 3);
	EXPECT_EQ(member1.GetCoeff(), 6);
	EXPECT_EQ(member1.GetDegree(), 3);
	TMember member2(3, 0);
	EXPECT_EQ(member2.GetCoeff(), 3);
	EXPECT_EQ(member2.GetDegree(), 0);
	TMember member3(0, 2);
	EXPECT_EQ(member3.GetCoeff(), 0);
	EXPECT_EQ(member3.GetDegree(), 2);
	TMember member4;
	EXPECT_EQ(member4.GetCoeff(), 0);
	EXPECT_EQ(member4.GetDegree(), 0);
}
TEST_F(TMemberTest, GetSetDegree) {
	TMember member(6, 3);
	EXPECT_EQ(member.GetDegree(), 3);
	member.SetDegree(2);
	EXPECT_EQ(member.GetDegree(), 2);
	member.SetDegree(-1);
	EXPECT_EQ(member.GetDegree(), -1);
	member.SetDegree(0);
	EXPECT_EQ(member.GetDegree(), 0);
}
TEST_F(TMemberTest, GetSetCoeff) {
	TMember member(6, 3);
	EXPECT_EQ(member.GetCoeff(), 6);
	member.SetCoeff(10);
	EXPECT_EQ(member.GetCoeff(), 10);
	member.SetCoeff(-1);
	EXPECT_EQ(member.GetCoeff(), -1);
	member.SetCoeff(0);
	EXPECT_EQ(member.GetCoeff(), 0);
}
TEST_F(TMemberTest, IsEqual) {
	TMember member1(6, 3);
	TMember member2(6, 3);
	TMember member3(4, 2);
	TMember member4(6, 2);
	EXPECT_TRUE(member1.IsEqual(member2));
	EXPECT_FALSE(member1.IsEqual(member3));
	EXPECT_FALSE(member1.IsEqual(member4));
}
TEST_F(TMemberTest, Differentiate) {
	TMember member1(6, 3);
	TMember derivative1 = member1.Differentiate();
	EXPECT_EQ(derivative1.GetCoeff(), 18);
	EXPECT_EQ(derivative1.GetDegree(), 2);
	TMember member2(3, 0);
	TMember derivative2 = member2.Differentiate();
	EXPECT_EQ(derivative2.GetCoeff(), 0);
	EXPECT_EQ(derivative2.GetDegree(), 0);
}
TEST_F(TMemberTest, Calculate) {
	TMember member1(6, 3);
	int result1 = member1.Calculate(2);
	EXPECT_EQ(result1, 48);
	TMember member2(3, 0);
	int result2 = member2.Calculate(5);
	EXPECT_EQ(result2, 3);
}
TEST_F(TMemberTest, ToString) {
	TMember member1(6, 3);
	std::string str1 = member1.ToString();
	EXPECT_EQ(str1, "6x^3");
	TMember member2(3, 0);
	std::string str2 = member2.ToString();
}