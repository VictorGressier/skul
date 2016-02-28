#include "Ant.h"



Ant::Ant(World* aWorld, int x, int y) : Organism(aWorld, x, y)
{

}


void Ant::move()
{
    moveRandomly();
    setMoved(true);
    breedTicks++;
}

void Ant::breed()
{
    if(breedTicks>=BREED_ANTS)
    {
        breedAtAdjacentCell();
    }
}

OrganismType Ant::getType() const
{
    return ANT;
}

char Ant::representation() const
{
    return 'o';
}

void Ant::generateOffspring(int whereX, int whereY)
{
    world->setAt(whereX,whereY, new Ant(world,whereX,whereY));
}
