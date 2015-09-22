using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface IGameSetting {
    bool LoadSettings();
    bool Init();
    bool UnInit();
}

