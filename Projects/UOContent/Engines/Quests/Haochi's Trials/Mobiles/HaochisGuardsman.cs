using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.Samurai
{
    public class HaochisGuardsman : BaseQuester
    {
        [Constructible]
        public HaochisGuardsman() : base("the Guardsman of Daimyo Haochi")
        {
        }

        public HaochisGuardsman(Serial serial) : base(serial)
        {
        }

        public override int TalkNumber => -1;

        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Hue = Race.Human.RandomSkinHue();

            Female = false;
            Body = 0x190;
            Name = NameList.RandomName("male");
        }

        public override void InitOutfit()
        {
            Utility.AssignRandomHair(this);

            AddItem(new LeatherDo());
            AddItem(new LeatherHiroSode());
            AddItem(new SamuraiTabi(Utility.RandomNondyedHue()));

            AddItem(
                Utility.Random(3) switch
                {
                    0 => new StuddedHaidate(),
                    1 => new PlateSuneate(),
                    _ => new LeatherSuneate()
                }
            );

            AddItem(
                Utility.Random(4) switch
                {
                    0 => new DecorativePlateKabuto(),
                    1 => new ChainHatsuburi(),
                    2 => new LightPlateJingasa(),
                    _ => new LeatherJingasa()
                }
            );

            AddItem(
                Utility.Random(3) switch
                {
                    0 => new NoDachi { Movable = false },
                    1 => new Lajatang { Movable = false },
                    _ => new Wakizashi { Movable = false }
                }
            );
        }

        public override void OnTalk(PlayerMobile player, bool contextMenu)
        {
        }

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
