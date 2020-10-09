#include <string>

#pragma once
class Car
{
	private:
		std::string Make;
		std::string Model;
		int year;
		std::string Color;
		float displacement;
		std::string EngineType;
		int ChrisFactor;
	public:
		Car(std::string Make, std::string Model, int year, std::string Color, float displacement, std::string EngineType, int ChrisFactor) : Make(Make), Model(Model), year(year), Color(Color), displacement(displacement), EngineType(EngineType), ChrisFactor(ChrisFactor) {}
		std::string GetMake();
		std::string GetModel();
		int GetYear();
		std::string GetColor();
		float GetDisplacement();
		std::string GetEngineType();
		int GetChrisFactor();
};