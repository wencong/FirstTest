using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IMiniGame {
    bool Load();
    bool Init();
    bool Start();
    void Update();
    bool Stop();
}

