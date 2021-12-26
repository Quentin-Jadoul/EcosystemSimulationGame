  ```mermaid
    
sequenceDiagram
Entity Manager->>Carnivorous: Update()
Carnivorous ->> Animal: Update()
Animal->>Living: Update()
Animal -> Animal: CheckForFood() 
Living -> Living: Energy--
alt Food Ok
Animal->>Living: Energy+=1000
    else 
 
   end
Animal->>Entity Manager: RemoveEntity(Food)
```