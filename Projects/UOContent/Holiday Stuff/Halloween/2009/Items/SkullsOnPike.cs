namespace Server.Items
{
    /*
    first seen halloween 2009.  subsequently in 2010,
    2011 and 2012. GM Beggar-only Semi-Rare Treats
    */

    public class SkullsOnPike : Item
    {
        [Constructible]
        public SkullsOnPike()
            : base(0x42B5)
        {
        }

        public SkullsOnPike(Serial serial)
            : base(serial)
        {
        }

        public override double DefaultWeight => 1;

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
