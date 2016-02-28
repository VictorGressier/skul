#include "Bug.h"

Bug::Bug(World* aWorld, int x, int y) :Organism(aWorld, x, y)
{
    starveTicks=0;
}

void Bug::move()
{
    bool eat = false;
    canIEat(eat);

    if(eat==false)
    {
        starveTicks++;
        moveRandomly();
    }
    setMoved(true);
    breedTicks++;
}

//Checks if an ant is close by
void Bug::canIEat(bool& eat)
{
    if(y!=WORLDSIZE-1 && (world->getAt(x,y+1) != NULL) && (world->getAt(x,y+1)->getType() == ANT))
    {
        deleteEatenAnt(x,y+1);
        y++;
        movesTo(x,y);
        starveTicks = 0;
        world->setAt(x,y-1,NULL);
        eat=true;
    }
    else if(y!=0 && (world->getAt(x,y-1) != NULL) && (world->getAt(x,y-1)->getType() == ANT))
    {
        deleteEatenAnt(x,y-1);
        y--;
        movesTo(x,y);
        starveTicks = 0;
        world->setAt(x,y+1,NULL);
        eat=true;
    }
    else if(x!=0 && (world->getAt(x-1,y) != NULL) && (world->getAt(x-1,y)->getType() == ANT))
    {
        deleteEatenAnt(x-1,y);
        x--;
        movesTo(x,y);
        starveTicks = 0;
        world->setAt(x+1,y,NULL);
        eat=true;
    }
    else if(x!=WORLDSIZE-1 && (world->getAt(x+1,y) != NULL) && (world->getAt(x+1,y)->getType() == ANT))
    {
        deleteEatenAnt(x+1,y);
        x++;
        movesTo(x,y);
        starveTicks = 0;
        world->setAt(x-1,y,NULL);
        eat=true;
    }
}

//deletes the allocated memory of the ant that was eaten
void Bug::deleteEatenAnt(int xCord, int yCord)
{
    delete world->getAt(xCord, yCord);
}

void Bug::breed()
{
    if(breedTicks>=BREED_BUGS)
    {
        breedAtAdjacentCell();
    }
}

OrganismType Bug::getType() const
{
    return BUG;
}

char Bug::representation() const
{
    return 'X';
}

bool Bug::isDead() const
{
    if(starveTicks >= STARVE_BUGS)
        return true;
    else
        return false;
}

void Bug::generateOffspring(int whereX, int whereY)
{
    world->setAt(whereX,whereY, new Bug(world,whereX,whereY));
}
