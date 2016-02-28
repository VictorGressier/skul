#include <iostream>
#include "Organism.h"
#include "World.h"
// Create an organism at the given coordinates in the given world
Organism::Organism(World* aWorld, int xcoord, int ycoord) {
    world = aWorld;
    x = xcoord;
    y = ycoord;
    breedTicks = 0;
    moved = false;
    world->setAt(x, y, this);
}


void Organism::setMoved(bool hasMoved) {   // flags the organism as moved or not
    moved = hasMoved;
}

bool Organism::hasMoved() const {  // has the organism moved or not?
    return moved;
}

// Makes a random move by calling movesTo().  Called by move() in the subclasses
void Organism::moveRandomly()
{
    Move to = world->randomMove();
    switch(to)
    {
    case LEFT:
        if(world->getAt(x-1,y) == NULL && x!=0)
        {
            x--;
            movesTo(x,y);
            world->setAt(x+1, y, NULL);
        }
       break;
    case RIGHT:
        if(world->getAt(x+1,y) == NULL && x!=WORLDSIZE-1)
        {
            x++;
            movesTo(x,y);
            world->setAt(x-1, y, NULL);
        }
       break;
    case DOWN:
        if(world->getAt(x,y-1) == NULL && y!=0)
        {
            y--;
            movesTo(x,y);
            world->setAt(x, y+1, NULL);
        }
        break;
    case UP:
        if(world->getAt(x,y+1) == NULL && y!=WORLDSIZE-1)
        {
            y++;
            movesTo(x,y);
            world->setAt(x, y-1, NULL);
        }
        break;
    }
}

void Organism::movesTo(int xNew, int yNew) // moves the organism from coordinates (x,y) to (xNew,yNew)
{
    world->setAt(xNew, yNew, this);
}

void Organism::breedAtAdjacentCell()
{
    if(y!=WORLDSIZE-1 && (world->getAt(x,y+1) == NULL))
    {
        breedTicks=0;
        generateOffspring(x,y+1);
    }
    else if(y!=0 && (world->getAt(x,y-1) == NULL))
    {
        breedTicks=0;
        generateOffspring(x,y-1);
    }
    else if(x!=0 && (world->getAt(x-1,y) == NULL))
    {
        breedTicks=0;
        generateOffspring(x-1,y);
    }
    else if(x!=WORLDSIZE-1 && (world->getAt(x+1,y) == NULL))
    {
        breedTicks=0;
        generateOffspring(x+1,y);
    }
}

bool Organism::isDead() const { // Returns true if organism is dead, false otherwise.
    return false;
}
