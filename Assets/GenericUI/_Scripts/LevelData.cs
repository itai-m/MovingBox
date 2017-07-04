﻿using System.Collections.Generic;

public interface LevelData {

    List<LevelWorld> GetWorldLevel();

    void Startlevel(LevelWorld world, int level);

    bool PauseGame();

    bool ResuemGame();

    bool isLevelOpen(LevelWorld world, int level);

}
