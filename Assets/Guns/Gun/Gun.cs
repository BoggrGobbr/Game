using System;

namespace Gun
{
    public abstract class Gun
    {
        private string name;
        private float shootPushSpeed, weight; //have pistol prefab shotgun prefab each with their own subclass as a script
        // have the shootVelocity biz in the gun Shot script maybe

        public string Name { get { return name; } set { name = value; } }
        public float ShootPushSpeed { get { return shootPushSpeed; } set { shootPushSpeed = value; } }
        public float Weight { get { return weight; } set { weight = value; } }
    }
}
