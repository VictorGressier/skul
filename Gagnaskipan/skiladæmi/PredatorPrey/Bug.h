#ifndef BUG_H
#define BUG_H
#include "Organism.h"
#include "World.h"
#include <iostream>
using namespace std;

class Bug : public Organism
{
public:
    Bug(World* aWorld, int x, int y);
    virtual void move();
    virtual void breed();
    virtual OrganismType getType() const;
    virtual char representation() const;
    virtual bool isDead() const;
    virtual void generateOffspring(int whereX, int whereY);



private:
    int starveTicks;
    //Checks if an ant is close by.
    //param bool eat: send in bool that is false in beginning and if it can eat it becomes true.
    void canIEat(bool& eat);
    void deleteEatenAnt(int xCord, int yCord);//deletes the allocated memory of the ant that was eaten on xCord and yCord.
};

#endif // BUG_H
