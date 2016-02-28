#ifndef ANT_H
#define ANT_H
#include "Organism.h"
#include "World.h"
#include <iostream>

class Ant : public Organism
{
public:
    Ant(World* aWorld, int x, int y);
    virtual void move();
    virtual void breed();
    virtual OrganismType getType() const;
    virtual char representation() const;
    virtual void generateOffspring(int whereX, int whereY);
};

#endif // ANT_H
